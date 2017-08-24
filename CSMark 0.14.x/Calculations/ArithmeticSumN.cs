﻿/*
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

namespace CSMark.Calculations
{
    class ArithmeticSumN{
        double SumN;

        public void calculateArithmeticSumN(double n, double d, double u1){
            SumN = (n / 2) * ((2 * u1) + (n - 1) * d);
        }
    }
}