namespace AppController.Tests.Mocks
{
    class Pistol : IWeapon
    {
        public Pistol(IWeaponComponent component, string name = "Desert Eagle")
        {
            Name = $"{name} with {component.Name}";
        }
        public string Name { get; set; }
    }
}
