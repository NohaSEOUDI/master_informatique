interface Plugin1{
    public default boolean subServiceTest(Plugin2 p){return false;}
    public default int subService1(){return 1;}
}
interface Plugin2{
    
    public default int subService2(){return 2;}
}
class ExamFrameWork{
    Plugin1 p1;   Plugin2 p2;

    ExamFrameWork(Plugin1 p1,Plugin2 p2){
        this.p1=p1;
        this.p2=p2;
    }
    public int service(){
        if(p1.subServiceTest(p2)) return p1.subService1();
        else return p2.subService2();
    }
}

class A implements Plugin1{}
class B implements Plugin2{}

class Main
{
	public static void main(String[] args) {
	    A a=new A();
	    B b=new B();
	    ExamFrameWork e= new ExamFrameWork(a,b);
		System.out.println(e.service());
	}
}
