using System;
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

    public string Brand     //2-20 tecken
    {
        get { return brand; }
        set
        {
            if (value.Length < 2 || value.Length > 20)
            {
                throw new ArgumentException("The brand name is either longer than 20 or less than 2 characters long"
                    , nameof(value));
            }
            brand = value;
        }
    }

    public double Weight    //Positive value
    {
        get { return weight; }
        set
        {
            if (value < 0.0)
            {
                throw new ArgumentException("Weight is less than 0???????"
                    , nameof(value));
            }
            weight = value;
        }
    }

    public int Year         //1886-current year
    {
        get { return year; }
        set
        {
            if (value < 1886 || value > DateTime.Now.Year)
            {
                throw new ArgumentException("Cars where invented in 1886 and cars can't be from the future"
                    , nameof(value));
            }
            year = value;
        }
    }

    public string Model     //2-20 tecken
    {
        get { return model; }
        set
        {
            if (value.Length < 2 || value.Length > 20)
            {
                throw new ArgumentException("The model name is either longer than 20 or less than 2 characters long"
                    , nameof(value));
            }
            model = value;
        }
    }

    abstract public void StartEngine();

    public string Stats()
    {
        string vehiclestats = $"{Brand} {Model} {Year} {Weight}";
        return vehiclestats;
    }

}




