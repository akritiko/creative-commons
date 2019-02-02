
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;

/**
 * @author Apostolos Kritikos
 * 
 * ��� ��� ���� ���������� ��� ������������ ���������� �� JDK Compliance �� ����
 * ������� �� 5.0. ����������� � enumeration class Category ��� �� ������������.
 * �� ��������� ������������� �� ArrayLisy. � ������������ ���� ���������� �����
 * ��������� ��������� ���� �������� ������ ��� �������� ���� ��� �����������
 * ���� ������������ ������. � �� ������� ����� ��� ������������ ������ ����� 10
 * ������. �� ����� ��� ����� ����������� ��� ������ ����������� �������
 * ����������� ��� �������� ��� ������ ���� � ����� ArrayList ����������� ��
 * �������� ����.
 * 
 */

public class Main {

	public static void main(String[] args) throws IOException {

		/**
		 * ���������� ��� �������� ������ ��� ���������
		 */
		System.out.flush();
		System.err.flush();

		/**
		 * ��������: � ���� ArrayList, ���� EmployeeHandler ��� ��� �������� /
		 * �������� ���������, ��� ��� ����������� Statistics ��� ��� ���������
		 * ��� ����������� (�� ��������� ��� �� ����������� Statistics
		 * ��������������� ��� ���������� ��� ���������� � �������� ���������.
		 */

		BufferedReader input = new BufferedReader(new InputStreamReader(
				System.in));
		ArrayList<DetailedEmployee> employees = new ArrayList<DetailedEmployee>();
		EmployeeHandler handler = new EmployeeHandler(employees);
		Statistics stats = new Statistics();

		int menuChoice;

		/**
		 * �����
		 */

		do {
			System.out.println();
			System.out.println("��������� ����������� ���������");
			System.out.println();
			System.out.println("(1) �������� ���������");
			System.out.println("(2) �������� ���������");
			System.out.println("(3) ���������� ������ ��������� �� ������");
			System.out.println("(4) ������� ������ ��������� ��� ������");
			System.out.println("(5) �������� �����������");
			System.out.println("(0) ������");

			System.out.println();
			System.out
					.print("�������� �������� ��������������� ��� ���������� ������: ");

			/**
			 * �� � ������� ����� invalid ��������� �� ��������� ��� ����������
			 * ������ ��� ������������� ��� loop ���� ������ ��������.
			 */

			try {

				menuChoice = Integer.parseInt(input.readLine());

			} catch (NumberFormatException e) {
				menuChoice = 6;
			}

			switch (menuChoice) {
			case 0:
				System.out.println();
				System.out.println("�� ��������� ������������!");
				break;
			case 1:
				handler.AddEmployee(stats);
				break;
			case 2:
				handler.deleteEmployee(stats);
				break;
			case 3:
				System.out.println("��� ���������");
				break;
			case 4:
				System.out.println("��� ���������");
				break;
			case 5:
				System.out.println();
				System.out.println("����������:");
				System.out.println();
				System.out.print("�������� ����������: ");
				System.out.print(stats.getTotalPayroll());
				System.out.println();
				
				/**
				 * ����������� �� ������� �� ���������� ��� ��������� ���������
				 */
				for (int i = 0; i < 3; i++) {

					System.out.print("���������� ");
					System.out.print(stats.getCategoryName(i));
					System.out.print(": ");
					System.out.print(stats.getCategorizedPayroll(i));
					System.out.println();
				}
				break;
			default:
				System.out.println();
				System.out.println("� ������� ������ �� ����� ������ 0-5");
				break;
			}

		} while (menuChoice != 0);

	}
}