# Unity Rigidbody Performance

유니티 물리 성능 측정 입니다.  
소수의 Actor 와 다수의 Bullet 간에 충돌 체크 성능 측정을 합니다.  

### 3가지 테스트  

1. Actor 와 Bullet 모두 Rigidbody 인 경우.  
2. Actor 는 Rigidbody 이고 Bullet 은 아닌 경우.
3. Bullet 은 Rigidbody 이고 Actor 는 아닌 경우.

### 결과  
Rigidbody 가 많을수록 느려집니다.
