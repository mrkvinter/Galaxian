namespace Scripts.AI.AI.Sensors
{
    public class OutOfScreenSensor : BaseSensor
    {
        public const string IsOutOfScreenParameter = "IsOutOfScreen";

        public float LineOfOutOfScreen;


        public override (string key, bool value) CollectSensor()
        {
            var isOut = transform.position.y < LineOfOutOfScreen;
            return (IsOutOfScreenParameter, isOut);
        }
    }
}