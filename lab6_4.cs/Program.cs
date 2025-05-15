using System;
using System.Collections;
using System.Collections.Generic;

class VectorByte : IEnumerable<byte>
{
    private byte[] _data;

    public VectorByte(int size)
    {
        _data = new byte[size];
        Random rand = new Random();
        for (int i = 0; i < size; i++)
            _data[i] = (byte)rand.Next(0, 256);
    }
    public byte this[int index]
    {
        get => _data[index];
        set => _data[index] = value;
    }
    public IEnumerator<byte> GetEnumerator()
    {
        foreach (var b in _data)
            yield return b;
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
class Program
{
    static void Main()
    {
        VectorByte vb = new VectorByte(5);

        Console.WriteLine("Елементи VectorByte через foreach:");
        foreach (byte b in vb)
            Console.WriteLine(b);
    }
}
