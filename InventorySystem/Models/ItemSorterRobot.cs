using System;
using Avalonia.Threading;

namespace InventorySystem.Models
{
    public class ItemSorterRobot : Robot
    {
        // URScript skabelon (simuleret)
        public const string UrscriptTemplate = @"
def move_item_to_shipment_box():
    SBOX_X = 3
    SBOX_Y = 3
    ITEM_X = {0}
    ITEM_Y = 1
    DOWN_Z = 1

    def moveto(x, y, z = 0):
        textmsg(""Moving to "", x, y, z)
    end

    moveto(ITEM_X, ITEM_Y)
    moveto(ITEM_X, ITEM_Y, DOWN_Z)
    moveto(SBOX_X, SBOX_Y)
end
";

        // 🦾 Simulerer at robotten udfører en handling
        public void PickUp(uint location)
        {
            try
            {
                string script = string.Format(UrscriptTemplate, location);
                SendUrscript(script);

                // Opdater status i UI (via event)
                Dispatcher.UIThread.Post(() =>
                    Log($"✅ Sent URScript for location {location}")
                );

                // Simulerer lidt ventetid (kun visuelt)
                Dispatcher.UIThread.Post(() =>
                    Log("🤖 Moving item to shipment box...")
                );
            }
            catch (Exception ex)
            {
                Dispatcher.UIThread.Post(() =>
                    Error($"❌ Robot error: {ex.Message}")
                );
            }
        }

        // 💬 Logbeskeder til UI
        private void Log(string message)
        {
            RaiseLog(message);
        }

        private void Error(string message)
        {
            RaiseError(message);
        }
    }
}