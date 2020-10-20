﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace DebtBook.Models
{
    public class DebitEntry : BindableBase
    {
        private string description;
        private double value;
        private DateTime timestamp;

        public DebitEntry(string description, double value, DateTime timestamp)
        {
            this.description = description;
            this.value = value;
            this.timestamp = timestamp;

        }

        public double Value
        {
            get => value;
            set => SetProperty(ref this.value, value);
        }

    }
}
