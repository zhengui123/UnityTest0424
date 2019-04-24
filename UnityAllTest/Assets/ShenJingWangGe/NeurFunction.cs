
using System;


public interface NeurFunction
{
    double Compute(double x);
}

public class SiFunction : NeurFunction
{
    public double Compute(double x)
    {
        return 1.0 / (1.0 + Math.Exp(-x)); //非线性激活函数
    }
}
public class ThFunction : NeurFunction
{
    public double Compute(double x)
    {
        return x > 0.0 ? 1.0 : -1.0;
    }
}
