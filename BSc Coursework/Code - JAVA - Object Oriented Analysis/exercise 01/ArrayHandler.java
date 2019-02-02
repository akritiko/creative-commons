import java.util.Random;

public class ArrayHandler { //� ����� ��� ���������� ��� ������������� ��� ������

	private int [] myArray;
	
	public ArrayHandler(int numberOfElements) //����������
	{
		//������������ ��� ������ ������� numberOfElements.
		myArray = new int [numberOfElements];
		
	}
	
	public void generateMyNumbers() //������� ��������� ������������ �������
	{
		int i;
		
		/* 
		 * ��������������� � ����� Random ��� ��������� ��� ������ 
		 * ������ java.util ��� ��� �������� ��� ������������ �������
		 * (���� ������� ��������).
		 */
		
		Random myRandomizer = new Random();
		
		for (i = 0; i < this.myArray.length; i++) //������� ��� ����� ���� ������
		{
			this.myArray[i] = myRandomizer.nextInt();
		}
	}
	
	public void bubbleSort() //������� ����������� �� ����� ��� ���������� bubbleSort
	{
		int i,j;
		
		for (i = 0; i < this.myArray.length - 1; i++)
			for (j = 0; j < this.myArray.length - 1 - i; j++)
				if (this.myArray[j + 1] < this.myArray[j])
				{
					int temp = this.myArray[j];
					this.myArray[j] = this.myArray[j + 1];
					this.myArray[j + 1] = temp;
				} 
	} 
	
	/*
	 * �������� ��� ��������� ���� �����. ��� ��� �������� ��� ����������� ��������
	 * �� �������� ������������ ����������. �� ��� � java ����� ��� ����� ���� ���
	 * ������ �� �������� � ��������� ����������� �� ���� ���� � ������� �� ������ 
	 * �� ������ �� 1 ��� ���� ��� ������ ����� ��������.
	 */
	
	public void printElements(int i, int j) 
	{
		int k;
		
		for (k = i-1;k<j;k++)
		{
			System.out.println(this.myArray[k] + ",");
		}		
	}

}
