public class Solution {
     int[] par;
    public int NumSimilarGroups(string[] strs) {
         par = new int[strs.Length];
        for(int i=0;i<par.Length;i++){
            par[i]=i;
        }
        int count = strs.Length;
        for(int i=0;i<strs.Length;i++){
            for(int j=i+1;j<strs.Length;j++){
                if(IsMatch(strs[i],strs[j])){
                   if(Find(j)!=Find(i)){
                    Unite(i,j);
                    count--;
                   }
                }
            }
        }
       return count;
    }

void Unite(int i, int j){
    int s = Find(i);
    int d = Find(j);
    if(s==d){
        return;
    }
    par[d]=s;
}
    int Find(int i){
        if(par[i]==i){
            return i;
        }
       return Find(par[i]);
    }

    void DFS(List<int>[] adj , bool[] vis, int sr){
        vis[sr]=true;
        foreach(int s in adj[sr]){
            if(!vis[s]){
                vis[s]=true;
                DFS(adj,vis,s);
            }
        }
    }

    bool IsMatch(string s1, string s2){
        if(s1.Length!=s2.Length){
            return false;
        }
        int count=0;
        for(int i=0;i<s1.Length;i++){
            if(s1[i]!=s2[i]){
                count++;
            }
        }
        return count<=2;
    }
}
