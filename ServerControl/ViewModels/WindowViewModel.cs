using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace ServerControl
{
    public class WindowViewModel: BaseViewModel
    {
        #region Private Member
        
        /// <summary>
        /// the window
        /// </summary>
        private Window window;

        /// <summary>
        ///  The margin around the window to allow for a drop shadow
        /// </summary>
        private int outerMarginSize = 10;

        /// <summary>
        /// the radius of the edges from the window
        /// </summary>
        private int windowRadius = 10;
        

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to open the system menu the window
        /// </summary>
        public ICommand MenuCommand { get; set; }

        /// <summary>
        /// The command to log out of the program
        /// </summary>
        public ICommand LogOutCommand { get; set; }

        /// <summary>
        /// The command to contact an administrator
        /// </summary>
        public ICommand ContactCommand { get; set; }

        /// <summary>
        /// Show the user management view
        /// </summary>
        public ICommand ShowUserManagement { get; set; }

        /// <summary>
        /// Show the server statistics view
        /// </summary>
        public ICommand ShowServerStats { get; set; }

        /// <summary>
        /// Show the navigation menu
        /// </summary>
        public ICommand ShowNavigation { get; set; }

        #endregion

        #region Public Properties

        public double WindowMinimumWidth { get; set; } = 400;

        public double WindowMinimumHeight { get; set; } = 300;

        /// <summary>
        /// the size of the resizeborder around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 2;

        /// <summary>
        /// the size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }
        
        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return window.WindowState == WindowState.Maximized ? 0 : outerMarginSize;
            }
            set
            {
                outerMarginSize = value;
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// the radius of the edges from the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return window.WindowState == WindowState.Maximized ? 0 : windowRadius;
            }
            set
            {
                windowRadius = value;
            }
        }

        /// <summary>
        /// the radius of the edges from the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// the height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 35;

        /// <summary>
        /// the height of the title bar
        /// </summary>
        public GridLength TitleHeightGridlength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder); } }

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        /// <summary>
        /// A <see cref="bool"/> that represents if someone is logged in
        /// </summary>
        public bool IsLoggedIn { get; set; } = false;

        /// <summary>
        /// A <see cref="bool"/> that represents if the navigation menu needs to be shown
        /// </summary>
        public bool ShowNavigationMenu { get; set; } = false;

        /// <summary>
        /// The text to display on the status bar
        /// </summary>
        public string StatusBarText { get; set; } = "Ready";

        /// <summary>
        /// A <see cref="bool"/> that represents if the status bar button should be displayed
        /// </summary>
        public bool StatusBarButtonVisibility { get; set; } = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="_window"></param>
        public WindowViewModel(Window _window)
        {
            window = _window;
            //Listen out for the window resizing
            window.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties affected by the resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            #region Commands

            MinimizeCommand = new RelayCommand(() => window.WindowState = WindowState.Minimized);
            // ^= is xor
            MaximizeCommand = new RelayCommand(() => window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(window, GetMousePosition()));

            LogOutCommand = new RelayCommand(() => {
                this.SetView(ApplicationPage.Login);
                WindowViewModelHelper.SetLoggedIn(false);
            });

            ContactCommand = new RelayCommand(() => {
                StatusBarText = "Ready";
                StatusBarButtonVisibility = false;
            });

            ShowUserManagement = new RelayCommand(() => {
                this.SetView(ApplicationPage.UserManagement);
            });

            ShowServerStats = new RelayCommand(() => {
                this.SetView(ApplicationPage.Plot);
            });

            ShowNavigation = new RelayCommand(() =>
            {
                this.ShowNavigationMenu = this.ShowNavigationMenu ? false : true;
            });

            #endregion

            // Fix window resize issue
            var resizer = new WindowResizer(window);
        }

        #endregion

        #region Private Helpers
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        private static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }
        #endregion
    }
}
