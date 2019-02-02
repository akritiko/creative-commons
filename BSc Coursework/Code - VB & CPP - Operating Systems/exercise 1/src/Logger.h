class Logger {
private:

    int sum_of_return_times;
    int sum_of_response_times;
    int count_of_return_times;
    int count_of_response_times;

public:
    Logger() {
        sum_of_return_times = 0;
        sum_of_response_times = 0;
        count_of_return_times = 0;
        count_of_response_times = 0;
    }

    void log( int return_time, int response_time ) {
        sum_of_return_times += return_time;
        ++count_of_return_times;
        sum_of_response_times += response_time;
        ++count_of_response_times;
    }

    void publish() {
        cerr << endl << "Ο μέσος χρόνος απόκρισης σε δείγμα " << count_of_response_times << " ήταν "
               << ( float )sum_of_response_times / count_of_response_times << endl;
        cerr << endl << "Ο μέσος χρόνος επιστροφής σε δείγμα " << count_of_return_times << " ήταν "
               << ( float )sum_of_return_times / count_of_return_times << endl;

    }
};

