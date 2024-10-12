namespace Player
{
    public static class PlayerInput
    {
        private static Controls Input { get; }
        public static Controls.OverworldActions Overworld { get; }
        public static Controls.InventoryActions Inventory { get; }
        
        static PlayerInput()
        {
            Input = new Controls();
            Input.Overworld.Enable();

            Overworld = Input.Overworld;
            Inventory= Input.Inventory;
        }
    }
}