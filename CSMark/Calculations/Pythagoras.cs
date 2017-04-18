using System;

namespace CSMark.Calculations
{
    class Pythagoras{
        private int opposite;
        private int adjacent;
        private int hypotenuse;
        private int hypotenuse_squared;
        private int adjacent_squared;
        private int opposite_squared;
        public void getOpposite(int _Hypotenuse, int _Adjacent){
            hypotenuse = _Hypotenuse;
            adjacent = _Adjacent;
            opposite_squared = (hypotenuse * hypotenuse) - (adjacent * adjacent);
            opposite = Convert.ToInt16(Math.Sqrt(opposite_squared));
        }
        public void getAdjacent(int _Hypotenuse, int _Opposite){
            hypotenuse = _Hypotenuse;
            opposite = _Opposite;
            adjacent_squared = (hypotenuse * hypotenuse) - (opposite * opposite);
            adjacent = Convert.ToInt16(Math.Sqrt(opposite_squared));
        }
        public void getHypotenuse(int _Adjacent, int _Opposite){
            adjacent = _Adjacent;
            opposite = _Opposite;
            hypotenuse_squared = (opposite * opposite) + (adjacent * adjacent);
            hypotenuse = Convert.ToInt16(Math.Sqrt(opposite_squared));
        }
        public int returnAdjacent(){
            return adjacent;
        }
        public int returnOpposite(){
            return opposite;
        }
        public int returnHypotenuse(){
            return hypotenuse;
        }
    }
}
