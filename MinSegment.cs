// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class HelloWorld
{
    static int[] ar;
    public static void Main(string[] args)
    {
       ar = new int[]{2,4,3,1,8};
       int l= ar.Length;
       int[] segmentTree = new int[4*l];
      // BuildTree(segmentTree,0,0,l-1);
      BuildMinTree(segmentTree,0,0,l-1);
       int res = QueryMin(0,4,0,4,segmentTree,0);//Query(0,4,3,4,segmentTree,0);
       Console.WriteLine(res);
    }
     static void PointUpdate(int[] sg, int l, int r , int ind,int curIndex, int val){
        if(l==r){
            sg[ind]=val;
            return;
        }
        int mid = (l+r)/2;
         if(curIndex<=mid){
            PointUpdate(sg,l,mid,ind*2+1,curIndex,val);
        }else{
            PointUpdate(sg,mid+1,r,ind*2+2,curIndex,val);
        }
        sg[ind]= Math.Min(sg[ind*2+1],sg[ind*2+2]);
    }
    static int Query(int l,int r, int s, int e, int[]sg, int ind){
        if(l>e||r<s){
            return 0;
        }
        if(l>=s && r<=e){
            return sg[ind];
        }
        int mid = (l+r)/2;
        return  Query(l,mid,s,e,sg,ind*2+1)+Query(mid+1,r,s,e,sg,ind*2+2);
    }
    
    static int QueryMin(int l,int r, int s, int e, int[]sg, int ind){
        if(l>e||r<s){
            return Int32.MaxValue;
        }
        if(l>=s && r<=e){
            return sg[ind];
        }
        int mid = (l+r)/2;
        return  Math.Min(QueryMin(l,mid,s,e,sg,ind*2+1),QueryMin(mid+1,r,s,e,sg,ind*2+2));
    }
    
    static void BuildTree(int[] sg, int ind , int l ,int r){
        if(l==r){
           sg[ind]= ar[l]; 
           return;
        }
        BuildTree(sg,ind*2+1,l,(l+r)/2);
         BuildTree(sg,ind*2+2,((l+r)/2)+1,r);
        sg[ind] = sg[ind*2+1]+sg[ind*2+2];
        
        
    }
    static void BuildMinTree(int[] sg, int ind , int l ,int r){
        if(l==r){
           sg[ind]= ar[l]; 
           return;
        }
        BuildMinTree(sg,ind*2+1,l,(l+r)/2);
         BuildMinTree(sg,ind*2+2,((l+r)/2)+1,r);
        sg[ind] = Math.Min(sg[ind*2+1],sg[ind*2+2]);
        
        
    }
}
