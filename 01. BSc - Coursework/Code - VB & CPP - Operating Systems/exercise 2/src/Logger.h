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

    void logResponseTime( int time ) {
        sum_of_response_times += time;
        ++count_of_response_times;
    }

    void logReturnTime( int time ) {
        sum_of_return_times += time;
        ++count_of_return_times;
    }

    void publish() {
        std::cout << std::endl << "Ο μέσος χρόνος απόκρισης σε δείγμα " << count_of_response_times << " ήταν "
             << ( float )sum_of_response_times / count_of_response_times << std::endl;
        /*std::cout << std::endl << "Ο μέσος χρόνος επιστροφής σε δείγμα " << count_of_return_times << " ήταν "
             << ( float )sum_of_return_times / count_of_return_times << std::endl;*/
    }
};
