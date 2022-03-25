abstract class A{
    public int m1(){
        if(this.m2(this)) return 1+ this.m3();
        else return 1 + this.m4();
    }
    public boolean m2(A a){return true;}
    public abstract int m3();
    public abstract int m4();
}
/*
class B extends A{
    
    public boolean m2(B b){return false;}
    public int m3(){return 1;}
    public int m4(){return 2;}
}*/
class C extends A{
    
    public boolean m2(A c){return false;}
    public int m3(){return 3;}
    public int m4(){return 4;}
}
class Main
{
	public static void main(String[] args) {
	    A a = new C();
		System.out.println(a.m1());
	}
}
