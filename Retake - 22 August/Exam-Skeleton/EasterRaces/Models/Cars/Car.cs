﻿using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;

            if (horsePower >= minHorsePower && horsePower <= maxHorsePower)
            {
                this.HorsePower = horsePower;

            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower,horsePower));
            }
        }

        public string Model
        {
            get 
            {
                return this.model;
            }
            private set 
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel,value,4));
                }

                this.model = value;
            }
        }
        public int HorsePower { get; private set; }
        public double CubicCentimeters { get; private set; }

        public virtual double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
