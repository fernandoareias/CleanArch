


#include <iostream>
using namespace std;
int main(){
 struct tm *local;
  time_t batata;

  batata = time(NULL);
  local = localtime(&batata);

  cout << local;
}
