
//Ici on applique le paramétrage par composition 
class Plugin1{
    public default boolean subServiceTest(Plugin2 p){return false;}
    public default int subService1(){return 1;}
}
class P1_1 extends Plugin1{
   
}
class P1_2 extends Plugin1{
   
}
class P1_3 extends Plugin1{
    
}
class Plugin2{
    public default int subService2(){return 2;}
}

class P2_1 extends Plugin2{
}
class P2_2 extends Plugin2{}
    
class P2_3 extends Plugin2{
}


class ExamFrameWork{
    Plugin1 p1;   Plugin2 p2;

    ExamFrameWork(Plugin1 p1,Plugin2 p2){
        this.p1=p1;
        this.p2=p2;
    }
    public int service(){
        if(p1.subServiceTest(p2)) //point d’extension, inversion de contrˆole ({\em callback})
            return p1.subService1(); 
        else 
            return p2.subService2();
    }
}

// Q7
class A implements Plugin1{ 
      public  boolean subServiceTest(Plugin2 p){return true;}
      public  int subService1(){return 11;}
}

//Q6
class B implements Plugin2{ 
     public int subService2(){return 22;}
}

class Main
{
	public static void main(String[] args) {
	    A a=new A();
	    B b=new B();
	    
	    ExamFrameWork e= new ExamFrameWork(a,b);
	    //injection de dépendance et invocation du service principal - class ExamFrameWork
		System.out.println(e.service());
	}
}

/*
une application doit être fermé à la modification (càd on touche pas au code source) 
et ouvert à l'extention (si on veut améliorer qqch il faut utiliser les extentions) */
