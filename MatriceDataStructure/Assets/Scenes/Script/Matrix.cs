
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
public class Matrix
{
    float[][] values;

    public Matrix(float[][] values)
    {
        this.values = (float[][])values.Clone();
    }
    public Coords ToCoords()
    {
        if (RowLength == 4 && ColumnLength == 1)
        {
            return new Coords(values[0][0], values[1][0], values[2][0], values[3][0]);
        }
        return null;
    }
    public int RowLength
    {
        get { return values.Length; }
    }
    public int ColumnLength
    {
        get { return Row(0).Length; }
    }
    public float[][] Rows()
    {
        return (from rows in values
                select rows).ToArray();
    }
    public float[] Row(int row)
    {
        return values[row];
    }
    public float[] Column(int column)
    {
        return (from rows in values
                select rows[column]).ToArray();
    }
    public float[][] Columns()
    {
        return values[0].Select((r, index) => Column(index)).ToArray();
    }
    public override string ToString()
    {
        var q = from rows in values
                select rows
                .Select((a) => a.ToString())
                .Aggregate((a, b) => a.ToString() + " " + b.ToString());
        return q.Aggregate((a, b) => a + Environment.NewLine + b);
    }
    static public Matrix TranslationMatrix(Coords coords)
    {
        return new Matrix(new float[][]{
            new float[]{1.0f,0.0f,0.0f, coords.x},
            new float[]{0.0f,1.0f,0.0f, coords.y},
            new float[]{0.0f,0.0f,1.0f, coords.z},
            new float[]{0.0f,0.0f,0.0f, 1.0f},
        });
    }
    static public Matrix ScaleMatrix(Coords coords)
    {
        return new Matrix(new float[][]{
            new float[]{coords.x,0.0f,0.0f, 0.0f},
            new float[]{0.0f, coords.y,0.0f, 0.0f},
            new float[]{0.0f,0.0f, coords.z, 0.0f},
            new float[]{0.0f,0.0f,0.0f, 1.0f},
        });
    }
    static public Matrix RollXRotationMatrix(float angle)
    {

        return new Matrix(new float[][]{
            new float[]{1.0f,0.0f,0.0f, 0.0f},
            new float[]{0.0f,Mathf.Cos(angle),-Mathf.Sin(angle), 0.0f},
            new float[]{0.0f,Mathf.Sin(angle), Mathf.Cos(angle), 0.0f},
            new float[]{0.0f,0.0f,0.0f, 1.0f},
        });
    }
    static public Matrix RollYRotationMatrix(float angle)
    {

        return new Matrix(new float[][]{
            new float[]{Mathf.Cos(angle),0.0f,Mathf.Sin(angle), 0.0f},
            new float[]{0.0f,1.0f,0.0f, 0.0f},
            new float[]{-Mathf.Sin(angle),0.0f, Mathf.Cos(angle), 0.0f},
            new float[]{0.0f,0.0f,0.0f, 1.0f},
        });
    }
    static public Matrix RollZRotationMatrix(float angle)
    {

        return new Matrix(new float[][]{
            new float[]{Mathf.Cos(angle),-Mathf.Sin(angle),0.0f, 0.0f},
            new float[]{Mathf.Sin(angle),Mathf.Cos(angle),0.0f, 0.0f},
            new float[]{0.0f,0.0f, 1.0f, 0.0f},
            new float[]{0.0f,0.0f,0.0f, 1.0f},
        });
    }
    static public Matrix ShearMatrix(Coords shear)
    {

        return new Matrix(new float[][]{
            new float[]{1.0f,shear.y,shear.z, 0.0f},
            new float[]{shear.x,1.0f,shear.z, 0.0f},
            new float[]{shear.x,shear.y,1.0f, 0.0f},
            new float[]{0.0f,0.0f,0.0f, 1.0f},
        });
    }
    static public Matrix operator +(Matrix m1, Matrix m2) => new Matrix((
        from rowsM2 in m2.values.Select((v, index) => new { Value = v, Index = index })
        join rowsM1 in m1.values.Select((v, index) => new { Value = v, Index = index }) on rowsM2.Index equals rowsM1.Index
        select rowsM1.Value.Select((r, index) => r + rowsM2.Value.ElementAt(index)))
        .Select((rows) => rows.ToArray()).ToArray());

    static public Matrix operator *(Matrix m1, Matrix m2)
    {
        var values = new List<IEnumerable<float>>();
        for (int i = 0; i < m1.values.Length; i++)
        {
            var rows = new List<float>();
            for (int j = 0; j < m2.Columns().Length; j++)
            {
                rows.Add(
                    m1.Row(i)
                    .Select((v, k) => v * m2.Column(j)[k])
                    .Aggregate((a, b) => a + b)
                );
            }
            values.Add(rows);
        }
        return new Matrix(values.Select((a) => a.ToArray()).ToArray());
    }
}
