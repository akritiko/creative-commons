
public class Main {

	public static void main(String[] args) {
		
		/*
		 * ��������� ��������� ��� buffer ������ ���� ����� ���� ��
		 * ����������� ������� �������� ��������� ���� ��� �������� 
		 * ���� �����.
		 */
		
		System.out.flush();
		
		//���������� ���� ������������ ����� ArrayHandler 50 ������
		ArrayHandler myExample = new ArrayHandler(50);
		
		//�������� ��� ������� �������
		myExample.generateMyNumbers();
		
		System.out.println();
		System.out.println("Elements before bubbleSort!");
		System.out.println("-------- ------ -----------");
		//�������� ��������� ���� ��� ����������
		myExample.printElements(1,50);
		
		//���������� �� bubbleSort
		myExample.bubbleSort();
		
		System.out.println();
		System.out.println("Elements after bubbleSort!");
		System.out.println("-------- ----- -----------");
		//�������� ��������� ���� ��� ����������
		System.out.println();
		myExample.printElements(1,50);		

	}

}
