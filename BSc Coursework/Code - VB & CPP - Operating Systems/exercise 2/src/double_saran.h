/* Καινοτομία: κλάση περιτυλίγματος τύπων, μπορει να φιλοξενεί οποιοδήποτε
τύπο και να τον κρατά φρέσκο μέχρι την τελευταία μπουκιά ! Σύντομα στα καταστήματα της γειτονιάς σας ! */

/* χρησιμοποιείται σαν στοιχείο δι-συνδετικής λίστας, με δείκτες στο
επόμενο[head] στο προηγούμενο[tail] και στο αντικείμενο καθαυτό που φιλοξενεί[value] */
#pragma once



template < class data >
class double_saran {
private:
    double_saran * _previous;
    double_saran * _next;
    data _value;

public:
    // δημιουργός
    double_saran( double_saran * Previous, double_saran * Next, data Value ) {
        _previous = Previous;
        _next = Next;
        _value = Value;
    }

    // αλλαγή κεφαλής
    void setNext( double_saran * Next ) {
        _next = Next;
    }

    // επιστρογή κεφαλής
    double_saran * getNext() {
        return _next;
    }

    // αλλαγή ουράς
    void setPrevious( double_saran * Previous ) {
        _previous = Previous;
    }

    // επιστροφή ουράς
    double_saran * getPrevious() {
        return _previous;
    }

    // επιστροφή φιλοξενούμενης τιμής
    data Value() {
        return _value;
    }
};
