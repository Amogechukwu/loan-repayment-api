#include <iostream>
#include <cmath>
#include <iomanip>
#include <cstdlib>

double monthlyPayment(double amount, double annualRate, int months) {
    if (months <= 0) return 0;
    double r = annualRate / 100.0 / 12.0;
    if (r == 0) return amount / months;
    double factor = std::pow(1 + r, months);
    return amount * r * factor / (factor - 1);
}

int main(int argc, char* argv[]) {
    if (argc != 4) {
        std::cout << "Usage: loancalc <amount> <annualRate> <months>\n";
        return 1;
    }
    double amount = std::atof(argv[1]);
    double rate = std::atof(argv[2]);
    int months = std::atoi(argv[3]);

    std::cout << std::fixed << std::setprecision(2);
    std::cout << "Monthly payment: " << monthlyPayment(amount, rate, months) << "\n";
    return 0;
}