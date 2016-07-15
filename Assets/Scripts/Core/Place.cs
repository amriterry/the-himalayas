namespace TheHimalayas.Core {

    public class Place {
        public string name;

        private float x;
        private float y;

        public float X {
            get {
                return x;
            }

            set {
                if(value > 1.0f) {
                    x = 1.0f;
                } else if(value < 0.0f) {
                    x = 0.0f;
                } else {
                    x = value;
                }
            }
        }

        public float Y {
            get {
                return y;
            }

            set {
                if (value > 1.0f) {
                    y = 1.0f;
                } else if (value < 0.0f) {
                    y = 0.0f;
                } else {
                    y = value;
                }
            }
        }
    }
}