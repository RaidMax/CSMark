/*
 CSMark
    Copyright (C) 2017  AluminiumTech

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
namespace CSMark.Calculations{
    class Trigonometry{
        private double angle;
        public void getCosAngle(double adjacent, double hypotenuse){
           angle = adjacent / hypotenuse;
           angle = Math.Cos(angle);
        }
        public void getSinAngle(double opposite, double hypotenuse){
            angle = opposite / hypotenuse;
            angle = Math.Sin(angle);
        }
        public void getTanAngle(double opposite,double adjacent){
            angle = opposite / adjacent;
            angle = Math.Tan(angle);
        }
    }
}