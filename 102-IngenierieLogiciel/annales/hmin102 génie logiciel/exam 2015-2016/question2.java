
abstract class Ordi{
    public boolean equiv(Ordi o, String s){
        System.out.println("Ordi");
        return true;
    }
}
class Montage extends Ordi{
      public boolean equiv(Montage m, String s){
        System.out.println("Montage");
        return false;
    }
}

class Ram extends Montage{}
    
public class Main
{
	public static void main(String[] args) {
	    Ordi m1 = new Ram();
	    Montage m2 = new Montage();
	    Ordi m3 = m2;
	    Ordi m4 = m1;
	    
	    m3.equiv(m3,"x");
	    m3.equiv((Montage)m3,"x");
	    m3.equiv(m4,"x");
	    
	    System.out.println("________________________________");
        
        
	    m4.equiv(m3,"x");
	    m4.equiv((Montage)m3,"x");
	    m4.equiv(m4,"x");
        System.out.println("________________________________");
        
	    System.out.println(m3.getClass().getSimpleName());
	    System.out.println(m4.getClass().getSimpleName());
	 
        
      
	
	    
	}
}
