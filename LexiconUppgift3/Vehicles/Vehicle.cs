﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.Vehicles;

abstract class Vehicle
{
    private string brand;
    private string model;
    private int year;
    private double weight;

    public Vehicle(string brand, string model, int year, double weight)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Weight = weight;
    }

    public string Brand     //Minimum 2 and maximum 20 characters.
    {
        get { return brand; }
        set
        {
            if (value.Length < 2 || value.Length > 20)
            {
                throw new ArgumentException("The brand name is either longer than 20 or less than 2 characters long."
                    , nameof(value));
            }
            brand = value;
        }
    }

    public double Weight    //Make sure vehicle doesn't weigh 0 kg or less.
    {
        get { return weight; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Weight can not be less than 4kg"
                    , nameof(value));
            }
            weight = value;
        }
    }

    public int Year         
    {
        get { return year; }
        set
        {   
            //Checking if value is less than 1886 and greater than the year it currently is.
            if (value < 1886 || value > DateTime.Now.Year)
            {
                throw new ArgumentException("1886 is too early and vehicles can't be from the future!"
                    , nameof(value));
            }
            year = value;
        }
    }

    public string Model     //Making sure model length is longer than 2 and shorter than 20.
    {
        get { return model; }
        set
        {
            if (value.Length < 2 || value.Length > 20)
            {
                throw new ArgumentException("The model name is either longer than 20 or less than 2 characters long."
                    , nameof(value));
            }
            model = value;
        }
    }

    public abstract void StartEngine();

    public virtual void Stats()
    {
        string vehiclestats = $"Brand: {Brand}{Environment.NewLine}Model: {Model}" +
            $"{Environment.NewLine}Year: {Year}{Environment.NewLine}Weight(kg): {Weight}";
        Console.WriteLine(vehiclestats);
    }

}




