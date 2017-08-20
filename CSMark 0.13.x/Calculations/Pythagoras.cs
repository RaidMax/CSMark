using System;

namespace CSMark.Calculations{
    class Pythagoras{
        private double opposite;
        private double adjacent;
        private double hypotenuse;
        private double hypotenuse_squared;
        private double adjacent_squared;
        private double opposite_squared;
        public void getOpposite(double _Hypotenuse, double _Adjacent){
            hypotenuse = _Hypotenuse;
            adjacent = _Adjacent;
            opposite_squared = (hypotenuse * hypotenuse) - (adjacent * adjacent);
            opposite = Math.Sqrt(opposite_squared);
        }
        public void getAdjacent(double _Hypotenuse, double _Opposite){
            hypotenuse = _Hypotenuse;
            opposite = _Opposite;
            adjacent_squared = (hypotenuse * hypotenuse) - (opposite * opposite);
            adjacent = Math.Sqrt(opposite_squared);
        }
        public void getHypotenuse(double _Adjacent, double _Opposite){
            adjacent = _Adjacent;
            opposite = _Opposite;
            hypotenuse_squared = (opposite * opposite) + (adjacent * adjacent);
            hypotenuse = Math.Sqrt(opposite_squared);
        }
        public double returnAdjacent(){
            return adjacent;
        }
        public double returnOpposite(){
            return opposite;
        }
        public double returnHypotenuse(){
            return hypotenuse;
        }
    }
}