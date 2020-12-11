#include <string.h>
#include <stdio.h>//perror
#include <sys/types.h>
#include <stdlib.h>
#include <unistd.h>
#include <iostream>
#include <pthread.h>


struct paramsFonctionThread {

  int num_ordre;
 // si d'autres param�tres, les ajouter ici.

};


void * fonctionThread (void * params){

  struct paramsFonctionThread *p = (struct paramsFonctionThread *) params;

  printf("je suis le thread num�ro %d , d�but d'�xecution\n",p->num_ordre );

  // Calcule
  int b=0;
  for (int i = 0; i < 100000000; ++i)
  {
  	b=b+5*9/63;
  }
   printf("je suis le thread num�ro %d , je suis en d'�xecution\n",p->num_ordre );
  // endormir le thread
  sleep(2);

 
  printf("je suis le thread num�ro %d , fin d'�xecution\n",p->num_ordre );

  pthread_exit(0);

}


int main(int argc, char * argv[]){

  if (argc < 2 ){
    printf("utilisation: %s  nombre_threads  \n", argv[0]);
    return 1;
  }     

  int *ret;
  pthread_t *threads;
  threads=(pthread_t *)malloc(atoi(argv[1])*sizeof(pthread_t));

  struct paramsFonctionThread *params;
  params =(paramsFonctionThread *)malloc(atoi(argv[1])*sizeof(paramsFonctionThread));
  
  // cr�ation des threards 
  for (int i = 0; i < atoi(argv[1]); i++){
    (params+i)->num_ordre =i;

   // compl�ter pour initialiser les param�tres
    if (pthread_create(&threads[i], NULL,fonctionThread,&params[i]) != 0){
      perror("erreur creation thread");
      exit(1);
    }
  }
  for (int i = 0; i < atoi(argv[1]); ++i){

	  pthread_join(threads[i],(void**)&ret);
  }

  return 0;
 
}
 
