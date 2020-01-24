
using System;
using System.Linq;
using System.Collections.Generic;
public class Matrix
{
    float[][] values;

    public Matrix(float[][] values)
    {
        this.values = (float[][])values.Clone();
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
    public override string ToString()
    {
        var q = from rows in values
                select rows
                .Select((a) => a.ToString())
                .Aggregate((a, b) => a.ToString() + " " + b.ToString());
        return q.Aggregate((a, b) => a + Environment.NewLine + b);
    }

    static public Matrix operator +(Matrix m1, Matrix m2) => new Matrix((
        from rowsM2 in m2.values.Select((v, index) => new { Value = v, Index = index })
        join rowsM1 in m1.values.Select((v, index) => new { Value = v, Index = index }) on rowsM2.Index equals rowsM1.Index
        select rowsM1.Value.Select((r, index) => r + rowsM2.Value.ElementAt(index)))
        .Select((rows) => rows.ToArray()).ToArray());

    static public Matrix operator *(Matrix m1, Matrix m2) => new Matrix((
    from rowsM1 in m1.values.Select((v, index) => new { Value = v, Index = index })
    join rowsM2 in m2.values.Select((v, index) => new { Value = m2.Column(index), Index = index }) on rowsM1.Index equals rowsM2.Index
    select rowsM1.Value.Select((r) => rowsM2.Value.Select((c) => c * r).Aggregate((a, b) => a + b)))
    .Select((rows) => rows.ToArray()).ToArray());
}
