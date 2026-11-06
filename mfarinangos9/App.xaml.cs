using mfarinangos9.Repositories;

namespace mfarinangos9
{
    public partial class App : Application
    {
        public static PersonRepository _personRepo { get; private set; } = null!;

        public App()
        {
            InitializeComponent();
            _personRepo = new PersonRepository(Path.Combine(FileSystem.AppDataDirectory, "personas.db3"));
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new Views.vPersona()));   
        }
    }
}