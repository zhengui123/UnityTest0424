using System;
using System.Collections.Generic;
 
 
    public class NeNetwork
{
    public double[][][] _NetWeights;
    public int[] _Layers;
    public double[][] _Offset;
    public double[][] _Outputs;
    public NeurFunction[][] Functions;

    public NeNetwork(params int[] Layers)
    {//(5,3)  5输入  3输出

        var layersLength = Layers.Length;
        this._Layers = Layers;//各层数量={5,3}

        _Outputs = new double[layersLength][];//输出={[5个],[3个]}

        for (var i = 0; i < layersLength; i++)
        {
            _Outputs[i] = new double[this._Layers[i]];
        }
        Functions = new NeurFunction[layersLength - 1][];//方法={[5个]}
        _NetWeights = new double[layersLength - 1][][];//权重={[[3个][3个][3个][3个][3个]]}
        _Offset = new double[layersLength - 1][];//偏移={[3个]}

        var func = new SiFunction();
        for (var i = 0; i < layersLength - 1; i++)
        {
            _NetWeights[i] = new double[this._Layers[i]][];
            Functions[i] = new NeurFunction[this._Layers[i]];
            for (var j = 0; j < this._Layers[i]; j++)
            {
                _NetWeights[i][j] = new double[this._Layers[i + 1]];
                Functions[i][j] = func;
            }
            _Offset[i] = new double[this._Layers[i + 1]];
        }
    }

    public void SetFunction(int layerIndex, NeurFunction func)
    {
        for (var j = 0; j < _Layers[layerIndex + 1]; j++)
        {
            Functions[layerIndex][j] = func;
        }
    }

    public double[] GetOut(double[] inputs)
    {

        for (var i = 0; i < _Layers[0]; i++)
        {
            _Outputs[0][i] = inputs[i];
        }
        var qqsout = new double[_Layers[_Layers.Length - 1]];
        for (var i = 1; i < _Layers.Length; i++)
        {
            for (var j = 0; j < _Layers[i]; j++)
            {// 3 
                double before = 0;
                for (var k = 0; k < _Layers[i - 1]; k++)
                { // 5
                    before += _Outputs[i - 1][k] * _NetWeights[i - 1][k][j];//权重这个J
                }
                before += _Offset[i - 1][j];
                _Outputs[i][j] = Functions[i - 1][j].Compute(before);//把三个输出层的结果发送到输出层方便调用
            }
        }
        qqsout = _Outputs[_Layers.Length - 1];
        return qqsout;

    }

    public List<double> GetWeightsList()
    {
        var qws = new List<double>();
        for (var i = 0; i < _Layers.Length - 1; i++)
        {
            qws.AddRange(_Offset[i]);
        }
        for (var i = 0; i < _Layers.Length - 1; i++)
        {
            for (var j = 0; j < _Layers[i]; j++)
            {
                qws.AddRange(_NetWeights[i][j]);
            }
        }
        return qws;
    }

    public void UpdateWeights(List<double> data)
    {
        var id = 0;
        for (var i = 0; i < _Layers.Length - 1; i++)
        {
            for (var j = 0; j < _Layers[i + 1]; j++)
            {
                _Offset[i][j] = data[id];
                id++;
            }
        }

        for (var i = 0; i < _Layers.Length - 1; i++)
        {
            for (var j = 0; j < _Layers[i]; j++)
            {
                for (var k = 0; k < _Layers[i + 1]; k++)
                {
                    _NetWeights[i][j][k] = data[id];
                    id++;
                }
            }
        }
    }

    //瞎JB写了
    public double[] ShowTimes()
    {  //反向传播权重更新
        List<double> currentList = new List<double>();
        for (int i = 0; i < _Layers[0]; i++)
        {
            currentList.Add(_Outputs[0][i]);
        }
        double a = -(_Outputs[0][1] - 0.5f) * _Outputs[0][1] * (1 - _Outputs[0][1]);  //-（输出-样本）*输出*（1-输出）；  反向传播加权
        double b = 1 / 1 - Math.Exp(-_Outputs[0][1]);   //非线性阶段函数
        double c = Math.Tanh(_Outputs[0][1]);     //切函数
        return currentList.ToArray();  //返回更新权重  然后数值更新 *学习率
    }

}

