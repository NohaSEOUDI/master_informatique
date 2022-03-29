/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/

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
	    Ordi m1= new Ram();
	    Montage m2= new Montage();
	    Ordi m3= new Montage();
	    
	    m2.equiv(m1,"x");
	    m2.equiv(m2,"x");
	    m2.equiv(m3,"x");
        m2.equiv((Montage)m3,"x");
        
        System.out.println("________________________________");
        
	    m3.equiv(m1,"x");
	    m3.equiv(m2,"x");
	    m3.equiv(m3,"x");
        m3.equiv((Montage)m3,"x");
	    
	}
}
