using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Drawing;
using System.Numerics;

namespace Gravity
{
    public class GravObject
    {
        public WindowsFormsApplication2.Form10 Form;
        public double X;
        public double Y;
        public Vector Velocity;
        public bool CanMove = true;
        public double VelocityScale = 1;
        public double Mass;
        public bool newast = true;
        public double timeswhat;

        public GravObject(WindowsFormsApplication2.Form10 Form, int X, int Y)
        {
            this.Form = Form;
            this.X = X;
            this.Y = Y;
            if(Form.isfull)
            {
                timeswhat = Form.timesfull;

            }
            else
            {
                timeswhat = Form.timesjup;
            }
        }



        public void Update(Color c, double track4)
        {
            Vector Force = new Vector(0, 0);
            foreach (GravObject g in Form.asteroids)
            {
                if (this != g)
                    Force += Grav(g);
            }
            double[][] storage;
            if (Form.iskep)
            {
                storage = Form.kepcoord;
            }     
            else
            {
                storage = Form.coords;
            }
            foreach (double[] planetsun in storage)
            {
                int counter = 0;
                if (X != planetsun[0] && Y != planetsun[1])
                {
                    Force += planetinter(planetsun, counter);
                }
                else
                {
                    Random s = new Random(Guid.NewGuid().GetHashCode());
                    int hit = s.Next(1, Convert.ToInt32(timeswhat));
                    if (hit <= Form.radiusarray[counter] * 2)
                    {
                        Form.labelarray[counter].Invoke((System.Windows.Forms.MethodInvoker)delegate
                        {
                            Form.labelarray[counter].Text = (Convert.ToInt32(Form.labelarray[counter].Text) + 1).ToString();
                        });

                        Random u = new Random(Guid.NewGuid().GetHashCode());
                        Random t = new Random(Guid.NewGuid().GetHashCode());
                        X = u.Next(1, 719);
                        Y = t.Next(1, 1279);
                        Velocity.X = 0;
                        Velocity.Y = 0;
                    }
                    else
                        Force += planetinter(planetsun, counter);
                }
                counter++;
            }
            if (Form.zeroed == false && newast)
            {
                double tAngle = Math.Atan2((Form.coords[0][1] - Y), (Form.coords[0][0] - X)) - (Math.PI / 2);
                double tMagnitude = Math.Sqrt(Form.gravconstant * ((Form.asteroidmass * 1000) + Form.massarray[0]) / Math.Sqrt((Math.Pow((Form.coords[0][0] - X), 2)) + (Math.Pow((Form.coords[0][1] - Y), 2)))) / timeswhat;
                Complex k = Complex.FromPolarCoordinates(tMagnitude, tAngle);
                Velocity = new Vector(k.Real, k.Imaginary);
                newast = false;
            }
            else
            { 
                double TimeElapsedSinceLastUpdate = 250 * Form.gravconstant;
                Vector acceleration = Force / (Form.asteroidmass * 1000);
                Velocity += acceleration * TimeElapsedSinceLastUpdate;
            }
            X = (X + Velocity.X * track4);
            Y = (Y + Velocity.Y * track4);
            
            if (X > 719 || X < 1 || Y> 1279 || Y< 1)
            {
                Random s = new Random(Guid.NewGuid().GetHashCode());
                Random t = new Random(Guid.NewGuid().GetHashCode());
                X = s.Next(1, 719);
                Y = t.Next(1, 1279);
                Velocity.X = 0;
                Velocity.Y = 0;
            }
            double[] xy = new double [] { X, Y };
            Pen pen = new Pen(c, 1);
            Form.drawPoint(xy, pen, 2);
        }

        public Vector Grav(GravObject other)
        {
            if ((Math.Abs(X - other.X) <= Form.asteroidmass * 1000 / timeswhat + other.Form.asteroidmass * 1000 / timeswhat) && (Math.Abs(Y - other.Y) <= Form.asteroidmass * 1000 / timeswhat + other.Form.asteroidmass * 1000 / timeswhat))
                return new Vector(0, 0);
            double tAngle = Math.Atan2((other.Y - Y), (other.X - X));
            double tMagnitude = (Form.gravconstant * Form.asteroidmass * 1000 * other.Form.asteroidmass * 1000 / Math.Abs(((Math.Pow((other.X - X), 2)) + (Math.Pow((other.Y - Y), 2))))) / Math.Pow(timeswhat, 2);
            Complex c = Complex.FromPolarCoordinates(tMagnitude, tAngle);
            Vector r = new Vector(c.Real, c.Imaginary);
            return r;
        }
        public Vector planetinter(double[] planetcoor, int which)
        {
            double tAngle = Math.Atan2((planetcoor[1] - Y), (planetcoor[0] - X));
            double tMagnitude = (Form.gravconstant * Form.asteroidmass * 1000 * Form.massarray[which] / Math.Abs(((Math.Pow((planetcoor[0] - X), 2)) + (Math.Pow((planetcoor[1] - Y), 2))))) / Math.Pow(timeswhat, 2);
            Complex c = Complex.FromPolarCoordinates(tMagnitude, tAngle);
            Vector r = new Vector(c.Real, c.Imaginary);
            return r;
        }
    }
}
