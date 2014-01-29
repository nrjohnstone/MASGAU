
// This file has been generated by the GUI designer. Do not modify.
namespace MASGAU.GTK
{
	public partial class MainWindow
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action btnRefreshGames;
		private global::Gtk.Action btnBackupGames;
		private global::Gtk.Action BackupAllGamesAction;
		private global::Gtk.VBox vbox1;
		private global::Gtk.Toolbar gamesToolbar;
		private global::Gtk.VBox vbox2;
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment GtkAlignment;
		private global::Gtk.FileChooserButton btnChooseBackupPath;
		private global::Gtk.Label GtkLabel2;
		private global::Gtk.HPaned hpaned1;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TreeView gameTreeView;
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		private global::Gtk.TreeView archiveTreeView;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Statusbar statusbar1;
		private global::Gtk.ProgressBar progressbar1;
		private global::Gtk.Button btnCancel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MASGAU.GTK.MainWindow
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.btnRefreshGames = new global::Gtk.Action ("btnRefreshGames", global::Mono.Unix.Catalog.GetString ("$RefreshGames"), null, "gtk-refresh");
			this.btnRefreshGames.IsImportant = true;
			this.btnRefreshGames.ShortLabel = global::Mono.Unix.Catalog.GetString ("$RefreshGames");
			w1.Add (this.btnRefreshGames, null);
			this.btnBackupGames = new global::Gtk.Action ("btnBackupGames", global::Mono.Unix.Catalog.GetString ("$BackupAllGames"), null, "gtk-save");
			this.btnBackupGames.ShortLabel = global::Mono.Unix.Catalog.GetString ("$BackupAllGames");
			w1.Add (this.btnBackupGames, null);
			this.BackupAllGamesAction = new global::Gtk.Action ("BackupAllGamesAction", global::Mono.Unix.Catalog.GetString ("$BackupAllGames"), null, null);
			this.BackupAllGamesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("$BackupAllGames");
			w1.Add (this.BackupAllGamesAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "MASGAU.GTK.MainWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("MASGAU.GTK.masgau.ico");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child MASGAU.GTK.MainWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><toolbar name=\'gamesToolbar\'><toolitem name=\'btnRefreshGames\' action=\'btnRefr" +
			"eshGames\'/><toolitem name=\'btnBackupGames\' action=\'btnBackupGames\'/><toolitem na" +
			"me=\'BackupAllGamesAction\' action=\'BackupAllGamesAction\'/></toolbar></ui>");
			this.gamesToolbar = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/gamesToolbar")));
			this.gamesToolbar.Name = "gamesToolbar";
			this.gamesToolbar.ShowArrow = false;
			this.vbox1.Add (this.gamesToolbar);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.gamesToolbar]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.btnChooseBackupPath = new global::Gtk.FileChooserButton (global::Mono.Unix.Catalog.GetString ("Select a File"), ((global::Gtk.FileChooserAction)(0)));
			this.btnChooseBackupPath.Name = "btnChooseBackupPath";
			this.GtkAlignment.Add (this.btnChooseBackupPath);
			this.frame1.Add (this.GtkAlignment);
			this.GtkLabel2 = new global::Gtk.Label ();
			this.GtkLabel2.Name = "GtkLabel2";
			this.GtkLabel2.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>$BackupFolder</b>");
			this.GtkLabel2.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel2;
			this.vbox2.Add (this.frame1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.frame1]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.vbox2]));
			w6.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hpaned1 = new global::Gtk.HPaned ();
			this.hpaned1.CanFocus = true;
			this.hpaned1.Name = "hpaned1";
			this.hpaned1.Position = 1;
			// Container child hpaned1.Gtk.Paned+PanedChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.gameTreeView = new global::Gtk.TreeView ();
			this.gameTreeView.CanFocus = true;
			this.gameTreeView.Name = "gameTreeView";
			this.gameTreeView.EnableSearch = false;
			this.GtkScrolledWindow.Add (this.gameTreeView);
			this.hpaned1.Add (this.GtkScrolledWindow);
			global::Gtk.Paned.PanedChild w8 = ((global::Gtk.Paned.PanedChild)(this.hpaned1 [this.GtkScrolledWindow]));
			w8.Resize = false;
			// Container child hpaned1.Gtk.Paned+PanedChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.archiveTreeView = new global::Gtk.TreeView ();
			this.archiveTreeView.CanFocus = true;
			this.archiveTreeView.Name = "archiveTreeView";
			this.GtkScrolledWindow1.Add (this.archiveTreeView);
			this.hpaned1.Add (this.GtkScrolledWindow1);
			this.vbox1.Add (this.hpaned1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hpaned1]));
			w11.Position = 2;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.statusbar1 = new global::Gtk.Statusbar ();
			this.statusbar1.Name = "statusbar1";
			this.statusbar1.Spacing = 6;
			// Container child statusbar1.Gtk.Box+BoxChild
			this.progressbar1 = new global::Gtk.ProgressBar ();
			this.progressbar1.Name = "progressbar1";
			this.statusbar1.Add (this.progressbar1);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.statusbar1 [this.progressbar1]));
			w12.Position = 1;
			// Container child statusbar1.Gtk.Box+BoxChild
			this.btnCancel = new global::Gtk.Button ();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = global::Mono.Unix.Catalog.GetString ("$Stop");
			global::Gtk.Image w13 = new global::Gtk.Image ();
			w13.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-cancel", global::Gtk.IconSize.Menu);
			this.btnCancel.Image = w13;
			this.statusbar1.Add (this.btnCancel);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.statusbar1 [this.btnCancel]));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			this.hbox1.Add (this.statusbar1);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.statusbar1]));
			w15.Position = 1;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w16.Position = 3;
			w16.Expand = false;
			w16.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 786;
			this.DefaultHeight = 451;
			this.Show ();
			this.DestroyEvent += new global::Gtk.DestroyEventHandler (this.OnDestroyEvent);
			this.btnRefreshGames.Activated += new global::System.EventHandler (this.OnRefreshGamesBtnActivated);
			this.btnBackupGames.Activated += new global::System.EventHandler (this.OnBtnBackupGamesActivated);
		}
	}
}
