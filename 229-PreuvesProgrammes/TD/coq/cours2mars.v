(* N est l'ensemble qui vérifie les propriétés suivantes :
1- O in N
2- Si n in N alors (S n) in N

Les entiers naturels vérifient les 2 propriétés.
Mais {-1, 0, 1, ...} vérifie aussi les 2 propriétés.
{-2, -1, 0, 1, ...} aussi !

Tarski : on prend l'intersection de tous les ensembles vérifiant les 2 propriétés et c'est bien le plus petit. *)

Inductive my_nat : Set :=
| my_0 : my_nat
| my_S : my_nat -> my_nat.

Check my_nat_ind.

(* my_nat_ind
     : forall P : my_nat -> Prop,
       P my_0 ->
       (forall m : my_nat, P m -> P (my_S m)) -> forall m : my_nat, P m*)

Print nat.
Check 0.
Check (S 0).
Check 1.

Print plus.
Print Nat.add.

(*
Nat.add = 
fix add (n m : nat) {struct n} : nat :=
  match n with
  | 0 => m
  | S p => S (add p m)
  end
     : nat -> nat -> nat

add (S p) m : add p m
R(S p, m) > R(p, m)
R(x, y) = x
(S p) > p : ordre structurel *)

Lemma ax1: forall x : nat, 0 + x = x.
Proof.
  intro.
  simpl.
  reflexivity.
Qed.

Lemma ex2 : forall x : nat, x + 0 = x.
Proof.
  (*induction x.*)
  intro.
  elim x.
  simpl; reflexivity.
  intros.
  simpl.
  rewrite H.
  reflexivity.
 Qed.
 
Require Export List.
Open Scope list_scope.
Import ListNotations.

Print list.

(* Inductive list (A : Type) : Type :=
    nil : list A
  | cons : A -> list A -> list A*)

Check (0 :: 1 :: 2 :: nil).

Print app.

(* 
app = 
fun A : Type =>
fix app (l m : list A) {struct l} : list A :=
  match l with
  | [] => m
  | a :: l1 => a :: app l1 m
  end
     : forall A : Type, list A -> list A -> list A*)

Lemma ex3 : forall (E :Type) (l : list E), nil ++ l = l.
Proof.
  intros.
  simpl.
  reflexivity.
Qed.

Lemma ex4 : forall (E : Type) (l : list E), l ++ nil = l.
Proof.
  intros.
  elim l.
  simpl.
  reflexivity.
  intros.
  simpl.
  rewrite H.
  reflexivity.
Qed.

Print Nat.mul.

Lemma exo1 : forall n : nat, n * 1 = n.
Proof.
  intros.
  elim n.
  simpl.
  reflexivity.
  intros.
  simpl.
  rewrite H.
  reflexivity.
Qed.

Fixpoint f (n: nat) :=
  match n with
  | 0 => 1
  | (S p) => 2 * (f p)
  end.

Lemma exo2 : (f 10) = 1024.
Proof.
  simpl.
  reflexivity.
Qed.

Eval compute in (rev (1 :: 2 :: 3 :: nil)).

Lemma exo3 : forall (E : Type) (l : (list E)) (a : E),
  rev (l ++ [a]) = a :: rev l.
Proof.
  intros.
  elim l; intros.
  simpl.
  reflexivity.
  simpl.
  rewrite H.
  simpl.
  reflexivity.
Qed.

Lemma exo4 : forall (E : Type) (l : (list E)), rev (rev l) = l.
Proof.
  intros.
  elim l; intros.
  simpl.
  reflexivity.
  simpl.
  rewrite (exo3 E (rev l0) a).
  rewrite H.
  reflexivity.
Qed.

(***********************)
(* Relations indutives *)
(***********************)

(* is_even(n) : N -> Prop 
1- is_even(0)
2- si n in N et si even(n) alors is even(n+2) *)

Inductive is_even : nat -> Prop :=
| is_even_0 : is_even 0
| is_even_S : forall n : nat, is_even n -> is_even (S (S n)).

Print is_even.

Check Prop.


Check is_even_ind.
Check is_even_0.
Check is_even_S.

Lemma ex5 : is_even 2.
Proof.
  apply is_even_S.
  apply is_even_0.
Qed.

Lemma ex6 : is_even 4.
Proof.
  apply is_even_S.
  apply is_even_S.
  apply is_even_0.
Qed.

Lemma ex7 : ~(is_even 3).
Proof.
  intro.
  inversion H.
  inversion H1.
Qed.

Lemma ex8 : ~(is_even 5).
Proof.
  intro.
  inversion H.
  inversion H1.
  inversion H3.
Qed.

Ltac prove_is_even :=
  (repeat apply is_even_S); apply is_even_0.
  
Lemma ex9: is_even 12.
  prove_is_even.
Qed.

Ltac prove_not_is_even :=
  intro;
  repeat
  (match goal with
  | H : is_even _ |- _ => inversion H; clear H
  end).
  
Lemma ex10: ~(is_even 11).
  prove_not_is_even.
 Qed.

Ltac prove_all :=
  prove_is_even || prove_not_is_even.
  
Lemma ex11 : is_even 36.
Proof.
  prove_all.
Qed.

Lemma ex12 : ~(is_even 37).
Proof.
  prove_all.
Qed.

Fixpoint f_is_even (n : nat) : bool :=
  match n with
  | 0 => true
  | 1 => false
  | (S (S p)) => (f_is_even p)
  end.
  
Require Import FunInd.

Functional Scheme f_is_even_ind :=
  Induction for f_is_even Sort Prop.
  
  
  
Lemma correction : forall n, (f_is_even n) = true -> is_even n.
Proof.
  (*intro.
  elim n.
  intro.
  apply is_even_0.
  intro.
  elim n0.
  intros.
  simpl in H0.
  inversion H0.
  intros.
  simpl in H1.*)
  intro.
  functional induction (f_is_even n) using f_is_even_ind.
  intro.
  apply is_even_0.
  intro.
  inversion H.
  intro.
  apply is_even_S.
  apply IHb.
  assumption.
 Qed.
 
 Lemma completude : forall n,
    is_even n -> (f_is_even n) = true.
Proof.
  intros.
  elim H.
  simpl.
  reflexivity.
  intros.
  simpl.
  assumption.
Qed.
 
Inductive sorted (A:Set)(R:A->A->Prop) : list A -> Prop :=
| sorted0 : sorted A R nil
| sorted1 : forall x:A, sorted A R (cons x nil)
| sorted2 :
forall (x y:A)(l:list A),
R x y ->
sorted A R (cons y l)-> sorted A R (cons x (cons y l)).

Check sorted.
Print sorted.
Print sorted_sind.
