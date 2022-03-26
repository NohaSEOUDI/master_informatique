/******************************************************************************

Si on supprime la méthode public abstract void rencontrer(Fontome f); de la classe Hero
et on tante d'executé le main : 
        Hero h = new Pacman();
		Fontome f = new Fontome();
		h.rencontrer(f);
on appelera la méthode rencontrer de la classe Hero et pas de la classe Pacman 
Car les types de paramétres étant différents, il s'agit de surcharge (Liaison Statique) 
Donc on suivra le type statique de h qui est de Type Hero 

*******************************************************************************/

class Elements{}
class Rencontrer extends Elements{}
class Fontome extends Rencontrer{}
class Cerise extends Rencontrer{}


abstract class Hero extends Elements{
    public void rencontrer(Rencontrer r){
    	System.out.println("Héro !");
    }
    //public abstract void rencontrer(Fontome f);
    //public abstract void rencontrer(Cerise c);
        
}

class Pacman extends Hero{
    public void rencontrer(Fontome r){
    	  System.out.println("Pacman rencontre un Fontome");
    }
}

class Main
{
	public static void main(String[] args) {
		Hero h = new Pacman();
		Fontome f = new Fontome();
		h.rencontrer(f);
	}
}
