﻿using System;
using System.Collections.Generic;
using System.IO;
using Collections;
using Config;
using MASGAU.Location.Holders;
namespace MASGAU.Location {

    public abstract class AScummVMLocationHandler : ALocationHandler {
        private TwoKeyDictionary<string, string, string> locations = null;
        private Dictionary<String, FileInfo> config_files;
        protected string install_path = null;

        public override bool ready {
            get { return config_files != null && config_files.Count > 0; }
        }



        public AScummVMLocationHandler()
            : base(HandlerType.ScummVM) {


        }

        protected abstract Dictionary<String, FileInfo> collectConfigFiles();
        protected abstract string findInstallPath();

        private void setup() {
            locations = new TwoKeyDictionary<string, string, string>();
            config_files = collectConfigFiles();
            foreach (String user in config_files.Keys) {
                IniFileHandler ini = new IniFileHandler(config_files[user]);
                foreach (string section in ini.Keys) {
                    if (ini[section].ContainsKey("savepath")) {
                        locations.Add(user, section, ini[section]["savepath"]);
                    }
                }
            }
            install_path = findInstallPath();
        }

        protected override DetectedLocations getPaths(ScummVMHolder get_me) {

            DetectedLocations return_me = new DetectedLocations();
            if (locations == null) {
                setup();
            }
            if (install_path != null) {
                return_me.AddRange(loadLocations(install_path, get_me, null));
            }
            foreach (string user in locations.Keys) {
                if (locations[user].ContainsKey("scummvm")) {
                    return_me.AddRange(loadLocations(locations[user]["scummvm"], get_me, user));
                }
                if (locations[user].ContainsKey(get_me.Name)) {
                    return_me.AddRange(loadLocations(locations[user][get_me.Name], get_me, user));
                }
            }


            return return_me;
        }

        protected DetectedLocations loadLocations(String path, ScummVMHolder scumm, string user) {
            DetectedLocations locs = Core.locations.interpretPath(path);

            locs = filterLocations(locs, scumm, user);

            return locs;
        }

        protected DetectedLocations filterLocations(DetectedLocations locs, ScummVMHolder scumm, string user) {
            List<string> keys = new List<string>(locs.Keys);

            foreach (string key in keys) {
                if (!filterLocation(locs[key], scumm, user)) {
                    locs.Remove(key);
                }
            }
            return locs;
        }

        protected bool filterLocation(DetectedLocationPathHolder loc, ScummVMHolder scumm, string user) {
            DirectoryInfo dir = new DirectoryInfo(loc.full_dir_path);
            string pattern = scumm.Name + "*";
            if (dir.GetFiles(pattern).Length > 0) {
                loc.owner = user;
                return true;
            }
            return false;

        }

    }
}
