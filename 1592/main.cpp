 #include <stdio.h>
 #include <vector>
 #include <algorithm>
 #include <numeric>
 
int main(){
    using uint = unsigned int;
    uint n, h, m, s;
    std::vector<uint> v;
    scanf("%u", &n);
    for(uint i = 0; i < n; i++)
        scanf("%u:%u:%u", &h, &m, &s), v.push_back((s + 60*(m+60*h))%(12*60*60));
    std::sort(v.begin(), v.end());
    uint sum = 12*60*60*n - std::accumulate(v.begin(), v.end(), 0);
    uint min = std::numeric_limits<uint>::max(), mint = 0, prev = 0;
    for(uint i = 0; i < n; prev = v[i++])
        if((sum += n*(v[i]-prev) - 12*60*60) < min)
            mint = v[i], min = sum;
    if(mint < 3600)
        mint += 3600*12;
    printf("%u:%02u:%02u", mint/3600, mint/60%60, mint%60);
}