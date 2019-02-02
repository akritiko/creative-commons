
/**
 * @author Apostolos Kritikos
 */

/**
 * ����� Statistics: ����� ���������� ��� ���� ���������� ��� �����������.
 */

public class Statistics {

	/**
	 * ������������� �� �������������� �� �����. ��� �� ������� ���� ���������
	 * ��� �� ���������� �� ����� for loop ��� ��� ������������ ��� ������ ��
	 * �����.
	 */

	private double totalPayroll = 0; // ��������

	private double[] categorizedPayroll = { 0, 0, 0 }; // ��� ���������

	/**
	 * @param totalPayroll
	 * @param categorizedPayroll
	 */

	/**
	 * ����� ���������� ���� ���� ���� ��� �� �������������� ����� ��������
	 */

	public Statistics() {

	}
	
	/**
	 * ������ ��� TotalPayroll 
	 */

	public void increaseTotalPayroll(double newPayroll) {
		this.totalPayroll = this.totalPayroll + newPayroll;
	}
	
	/**
	 * ������ ��� TotalPayroll ��� ���������
	 */

	public void increaseCategorizedPayroll(Category category, double newPayroll) {
		switch (category) {
		case TIMEWORKER:
			this.categorizedPayroll[0] = this.categorizedPayroll[0]
					+ newPayroll;
			break;
		case WAGEWORKER:
			this.categorizedPayroll[1] = this.categorizedPayroll[1]
					+ newPayroll;
			break;
		case SUPERVISOR:
			this.categorizedPayroll[2] = this.categorizedPayroll[2]
					+ newPayroll;
			break;
		}
	}

	/**
	 * ������ ��� TotalPayroll 
	 */

	
	public void decreaseTotalPayroll(double newPayroll) {
		this.totalPayroll = this.totalPayroll - newPayroll;
	}
	
	/**
	 * ������ ��� TotalPayroll ��� ���������
	 */


	public void decreaseCategorizedPayroll(Category category, double newPayroll) {
		switch (category) {
		case TIMEWORKER:
			this.categorizedPayroll[0] = this.categorizedPayroll[0]
					- newPayroll;
			break;
		case WAGEWORKER:
			this.categorizedPayroll[1] = this.categorizedPayroll[1]
					- newPayroll;
			break;
		case SUPERVISOR:
			this.categorizedPayroll[2] = this.categorizedPayroll[2]
					- newPayroll;
			break;
		}
	}
	
	/**
	 * ���������� �� ������� ��� ���������� ���������
	 */

	
	public String getCategoryName(int choice) {

		switch (choice) {
		case 0:
			return "����������";
		case 1:
			return "��������";
		case 2:
			return "���������";
		default:
			return "";
		}
	}

	/**
	 * @return Returns the categorizedPayroll.
	 */
	public double getCategorizedPayroll(int choice) {
		return categorizedPayroll[choice];
	}

	/**
	 * @return Returns the totalPayroll.
	 */
	public double getTotalPayroll() {
		return totalPayroll;
	}

}
