/* ����������: ����� �������������� �����, ������ �� ��������� �����������
���� ��� �� ��� ����� ������ ����� ��� ��������� ������� ! ������� ��� ����������� ��� ��������� ��� ! */

/* ��������������� ��� �������� ��-���������� ������, �� ������� ���
�������[head] ��� �����������[tail] ��� ��� ����������� ������� ��� ���������[value] */
#pragma once



template < class data >
class double_saran {
private:
    double_saran * _previous;
    double_saran * _next;
    data _value;

public:
    // ����������
    double_saran( double_saran * Previous, double_saran * Next, data Value ) {
        _previous = Previous;
        _next = Next;
        _value = Value;
    }

    // ������ �������
    void setNext( double_saran * Next ) {
        _next = Next;
    }

    // ��������� �������
    double_saran * getNext() {
        return _next;
    }

    // ������ �����
    void setPrevious( double_saran * Previous ) {
        _previous = Previous;
    }

    // ��������� �����
    double_saran * getPrevious() {
        return _previous;
    }

    // ��������� �������������� �����
    data Value() {
        return _value;
    }
};
