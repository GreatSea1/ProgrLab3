using System;

namespace ProgrLab3
{

	public class DeepStructure
	{
		public int A { get; set; }
	}

	class ShallowCloneMatrix : SquareMatrix, ICloneable
	{
		public object Clone()
		{
			return (SquareMatrix)this.MemberwiseClone();
		}
	}

	public class SquareMatrix
	{
		private int[,] Matrix;
		public float Determinant = new Random().Next(1, 10);
		public DeepStructure DS;
		public SquareMatrix()
		{
			Matrix = new int[3, 3];
			DS = new DeepStructure();
		}

		public void FillRandom()
		{
			for (int Line = 0; Line < 3; ++Line)
			{
				for (int Column = 0; Column < 3; ++Column)
				{
					Matrix[Line, Column] = new Random().Next(1, 10);
					Console.Write("{0} ", Matrix[Line, Column]);
				}
				Console.WriteLine();
			}
			Console.WriteLine("Детерминант: {0}", Determinant);
			Console.WriteLine();
		}

		public static float operator /(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix)
		{
			return FirstMatrix.Determinant / SecondMatrix.Determinant;
		}
		public static float operator *(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix)
		{
			return FirstMatrix.Determinant * SecondMatrix.Determinant;
		}
		public static float operator +(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix)
		{
			return FirstMatrix.Determinant + SecondMatrix.Determinant;
		}

		public static float operator -(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix)
		{
			return FirstMatrix.Determinant - SecondMatrix.Determinant;
		}

		public static bool operator ==(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix)
		{
			return FirstMatrix.Determinant == SecondMatrix.Determinant;
		}

		public static bool operator !=(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix)
		{
			return FirstMatrix.Determinant != SecondMatrix.Determinant;
		}

		public override bool Equals(object Other)
		{
			if (Other == null)
			{
				return false;
			}

			if (!(Other is SquareMatrix))
			{
				return false;
			}

			return (this.Matrix == ((SquareMatrix)Other).Matrix);
		}
		public override int GetHashCode()
		{
			int HashCode = 0;
			for (int Line = 0; Line < 3; ++Line)
			{
				for (int Column = 0; Column < 3; ++Column)
				{
					HashCode += Matrix[Line, Column];
				}
			}
			return HashCode;
		}
		public int CompareTo(object Object)
		{
			if (Object == null)
			{
				return 1;
			}

			SquareMatrix OtherMatrix = Object as SquareMatrix;
			if (OtherMatrix == null)
			{
				throw new ArgumentException("Object is not a Matrix");
			}

			return CompareTo(OtherMatrix);
		}
		public override string ToString()
		{
			return base.ToString();
		}
	}
}