import java.io.*;
import java.util.ArrayList;
import java.util.Random;

/**
 * @author Apostolos Kritikos
 * 
 * ����� EmployeeHandler: ����������� ��� �������� ��� �������� ��������� ��� ��
 * ������� ��� ���������� ��� ������ ��������� ��� �������� ���� ����� Main.
 * ���� ������� ��������������� �� �������� ��������� �� ���� ��� ������ �������
 * ���.
 * 
 */

public class EmployeeHandler {

	private ArrayList<DetailedEmployee> employees;

	/**
	 * @param currentNumberOfEmployees
	 * @param currentEmployees
	 */

	public EmployeeHandler(ArrayList<DetailedEmployee> employees) {

		this.employees = employees;
	}

	public void AddEmployee(Statistics stats) throws IOException {

		Random randomizer = new Random();
		BufferedReader input = new BufferedReader(new InputStreamReader(
				System.in));
		DetailedEmployee newEmployee;

		// ������� ���� ������� ������� ������ ��� 0 ��� 1000000 ��� �������
		// �������
		int recordNumber = randomizer.nextInt(1000000);
		String name = new String();
		String specialty = new String();
		int numberOfChildren;
		int choice;

		System.out.println();
		System.out.println("�������� ���� ���������");
		System.out.println();

		System.out.print("�������������: ");
		name = input.readLine();

		System.out.print("����������: ");
		specialty = input.readLine();

		System.out.println();
		System.out.print("���������: ");
		System.out.println();
		System.out.println("���������� (1)");
		System.out.println("�������� (2)");
		System.out.println("��������� (3)");
		System.out.println();
		System.out
				.print("�������� ��������� ���������� ��� ��������� ������: ");

		/**
		 * ��� ��������� � ����� ��� ������� ��� ��� ������ ��� �� ��� �����
		 * �������������� ������������ ��� �����
		 */
		try {
			choice = Integer.parseInt(input.readLine());

		} catch (NumberFormatException e) {
			return;
		}
		System.out.flush();
		System.out.print("������� ������: ");

		/**
		 * ��� ��������� � ����� ��� ������� ��� ��� ������ ��� �� ��� �����
		 * �������������� ������������ ��� �����
		 */
		try {
			numberOfChildren = Integer.parseInt(input.readLine());
		} catch (NumberFormatException e) {
			return;
		}

		/**
		 * ��� ������������ ��� ����������� ����� DetailedEmployee ��� ��
		 * ������������� �� �� �������� ��� ������ ��� ��� ������. ����������
		 * ��� ��������� ��� ������� ������� ��� ��������� �� �� ���������
		 * ������. ������ ������������ ��������� ��� �� ����������.
		 */

		switch (choice) {
		case 1:
			newEmployee = new DetailedEmployee(name, recordNumber, specialty,
					Category.TIMEWORKER, numberOfChildren);
			employees.add(newEmployee);
			/**
			 * ��������� �����������
			 */
			increaseStatistics(stats, newEmployee);
			break;
		case 2:
			newEmployee = new DetailedEmployee(name, recordNumber, specialty,
					Category.WAGEWORKER, numberOfChildren);
			employees.add(newEmployee);
			/**
			 * ��������� �����������
			 */
			increaseStatistics(stats, newEmployee);
			break;
		case 3:
			newEmployee = new DetailedEmployee(name, recordNumber, specialty,
					Category.SUPERVISOR, numberOfChildren);
			employees.add(newEmployee);
			/**
			 * ��������� �����������
			 */
			increaseStatistics(stats, newEmployee);
			break;
		}
	}

	public void deleteEmployee(Statistics stats) throws IOException {

		BufferedReader input = new BufferedReader(new InputStreamReader(
				System.in));
		boolean wasDeleted = false;
		// ��� ������������ � ������� ������� ��� "�������"
		int victimsRecordNumber;

		/**
		 * �������� ��� ��������� ���� ����� ��� �� �������� � ������� ����� ��
		 * ���������.
		 */

		System.out.println();
		System.out.println("������������ ���������");
		System.out.println();
		System.out.println("�������������" + '\t' + '\t' + "��. �������");
		System.out.println();

		for (int i = 0; i < employees.size(); i++) {
			System.out.println(employees.get(i).getName() + '\t' + '\t'
					+ employees.get(i).getRecordNumber());
		}

		System.out.println();
		System.out
				.println("�������� ��� ������ ������� ��� ��������� ��� ������ �� ����������: ");

		/**
		 * ��� ��������� � ����� ��� ������� ��� ��� ������ ��� �� ��� �����
		 * �������������� ������������ ��� �����
		 */
		try {
			victimsRecordNumber = Integer.parseInt(input.readLine());
		} catch (NumberFormatException e) {
			return;
		}

		for (int i = 0; i < employees.size(); i++) {
			if (employees.get(i).getRecordNumber() == victimsRecordNumber) {

				// �������� �� ���������� ���� �� ������
				decreaseStatistics(stats, employees.get(i));

				employees.remove(i);

				// � �������� �����
				wasDeleted = true;
			}
		}
		if (!wasDeleted) {
			System.out.println();
			System.out.println("� ��������� ��� �������");
		} else {
			System.out.println();
			System.out.println("� ��������� �������� �� ��������!");
		}
	}

	/**
	 * ������ ��� ����������� �� ����� ��� ������� ��� ������ ���� (��������
	 * ���������) ��� ��� ��������� �����
	 */

	private void increaseStatistics(Statistics stats,
			DetailedEmployee newEmployee) {
		stats.increaseCategorizedPayroll(newEmployee.getCategory(), newEmployee
				.getTotalSalary());

		stats.increaseTotalPayroll(newEmployee.getTotalSalary());

	}

	/**
	 * ������ ��� ����������� �� ����� ��� ������� ��� ������ ���� (��������
	 * ���������) ��� ��� ��������� �����
	 */

	
	private void decreaseStatistics(Statistics stats,
			DetailedEmployee newEmployee) {
		stats.decreaseCategorizedPayroll(newEmployee.getCategory(), newEmployee
				.getTotalSalary());
		stats.decreaseTotalPayroll(newEmployee.getTotalSalary());
	}
}
