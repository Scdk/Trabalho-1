using System;
using System.Numerics;

public class Qubit
{
    public double theta { get; private set; }
    public double phi { get; private set; }
    public Complex a { get; private set; }
    public Complex b { get; private set; }

    public Qubit()
    {
        // theta and phi are bloch spheres
        // a and b are wave functions
        // Default: |0>
        theta = 0.0;
        phi = 0.0;
        a = new Complex(1, 0);
        b = new Complex(0, 0);
    }

    public Complex[,] waveFunction()
    {
        // Returns wave function in fatorial form
        Complex[,] wf = {{a}, {b}};
        return wf;
    }

    public void set_bs(double _theta, double _phi)
    {
        if(!(0.0 <= _theta && _theta <= Math.PI))
        {
            _theta = Math.PI - (_theta % Math.PI);
        }
        if(!(-Math.PI <= _phi && _phi <= Math.PI))
        {
            _phi = (_phi % 2*Math.PI) - 2*Math.PI;
        }
        theta = _theta;
        phi = _phi;
    }

    public void set_pa(Complex _a, Complex _b)
    {
        double aux = Math.Pow(Complex.Abs(_a), 2) + Math.Pow(Complex.Abs(_b), 2);
        _a = new Complex(Math.Sqrt(Math.Pow(Complex.Abs(_a), 2) / aux), 0);
        _b = new Complex(Math.Sqrt(Math.Pow(Complex.Abs(_b), 2) / aux), 0);
        var ma = _a.Magnitude;
        var pa = _a.Phase;
        var mb = _b.Magnitude;
        var pb = _b.Phase;
        a = new Complex(ma, 0);
        b = new Complex(mb, 0) * Complex.Exp(new Complex(0, 1) * (new Complex(0, pb) - new Complex(0, pa)));
    }
}