namespace Player
{
    public static class PlayerInput
    {
        private static Controls Input { get; }
        public static Controls.OverworldActions Overworld { get; }
        public static Controls.InventoryActions Inventory { get; }


        private static InputSystem currentSystem; 
        

        public enum InputSystem
        {
            Overworld,
            Inventory
        }
        
        static PlayerInput()
        {
            Input = new Controls();
            Input.Overworld.Enable();

            Overworld = Input.Overworld;
            Inventory= Input.Inventory;
        }


        public static void ChangeInputSystem(InputSystem system)
        {
            if (system == currentSystem) return;
            
            switch (currentSystem)
            {
                case InputSystem.Overworld: Overworld.Disable();
                    break;
                case InputSystem.Inventory: Inventory.Disable();
                    break;
            }

            switch (system)
            {
                case InputSystem.Overworld: Overworld.Enable();
                    break;
                case InputSystem.Inventory: Inventory.Enable();
                    break;
            }

            currentSystem = system;
        }
    }
}