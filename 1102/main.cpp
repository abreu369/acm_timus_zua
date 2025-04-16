#include <iostream>
#include <string>
#include <algorithm>

using namespace std;

string a[] = {"ni","eno","tuo","tupni","notup","tuptuo"};
string s;
int ls;

string::reverse_iterator beg;

bool cmp() {
	int al;
	if(ls==0)
		return true;
	for (int i=0; i<6; i++) {
		al = a[i].length();
		if(ls >= al) {
			if(string(beg,beg+al)==a[i]) {
				ls-=al;
				beg+=al;
				return true;
			}
		} else {
			break;
		}
	}
	return false;
}


int main() {
	int n;
	scanf("%d",&n);
	for (int i=0; i<n; i++) {
		cin >> s;
		ls = s.size();
		beg=s.rbegin();
		while(cmp() && ls!=0) {
			cmp();
		}
		if(ls==0)
			printf("YES\n");
		else
			printf("NO\n");
	}
	return 0;
}


