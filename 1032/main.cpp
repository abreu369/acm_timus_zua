#include <cstdio>
#include <algorithm>
#include <iostream>

using namespace std;

int A[10500];
int S[10500];

int main() {
    
    int n;
    scanf("%d", &n);
    int s = 0;
    S[0] = 0;
    
    for (int i=0; i<n; i++) {
        scanf("%d", &A[i]);
        s+=A[i];
        S[i+1]=s;
    }
    
    for (int i=0; i<n+1; i++) {
        for (int j=0; j<i; j++) {
            if ((S[i]-S[j])%n==0) {
                printf("%d\n", i-j);
                for (int k=j; k<i; k++)
                    printf("%d ", A[k]);
                return 0;
            }
        }
    }
    
    printf("0\n");
    
	return 0;
}