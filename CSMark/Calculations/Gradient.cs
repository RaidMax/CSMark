namespace CSMark.Calculations{
    class Gradient{
        private int gradient;
        public void getGradient(int y2, int y1, int x2, int x1){
            gradient = (y2 - y1) / (x2 - x1);
        }
    }
}