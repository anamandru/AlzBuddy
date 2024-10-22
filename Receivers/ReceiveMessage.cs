using System.Text.RegularExpressions;

namespace AlzBuddy.Receivers
{
    public class ReceiveMessage
    {
        public AlzBuddyDB db = new AlzBuddyDB();

        public void AddReceivedData(string message)
        {
            // Structure of the receive data
            // "{\"CO PPM\":\"247.73\",\"Distance\":null,\"Door_open_seconds\":\"5\",\"Temperature(C)\":\"23.00\",\"Water Level\":\"0\",\"dist  cm\":\"123.11\"}\n"

            string pattern = "\"([^\"]*)\":\"([0-9]+(\\.[0-9]+)?)\"";

            MatchCollection matches = Regex.Matches(message, pattern);

            double temperature, coPpm;
            int water, seconds;

            foreach (Match match in matches)
            {
                string key = match.Groups[1].Value;
                string value = match.Groups[2].Value;

                switch (key)
                {
                    case "Temperature(C)":
                        double.TryParse(value, out temperature);
                        Globals.currentTemperature = temperature;
                        break;
                    case "CO PPM":
                        double.TryParse(value, out coPpm);
                        Globals.currentCoPpm = coPpm;
                        break;
                    case "Door_open_seconds":
                        int.TryParse(value, out seconds);
                        Globals.currentDoorOpenSeconds = seconds;
                        break;
                    case "Water Level":
                        int.TryParse(value, out water);
                        Globals.currentWaterLevel = water;
                        break;
                }
            }                 
        }

    }
}
