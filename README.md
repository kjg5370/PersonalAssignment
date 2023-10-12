<h2>[2022] UP & Fight 🎮</h2>

**(점프 맵 만들기)**

3D 게임에 익숙해지고 FSM이 어떻게 동작하는지 알아보기 위해 점프 맵을 꾸며보았습니다<br> 프로빌더를 사용해 맵에 도형들을 제작하였습니다.😊
</div>

## 목차
  - [개요](#개요) 
  - [설명](#설명)
  - [게임 화면](#게임-화면)
  - [게임 요소](#게임-요소)

## 개요
- 프로젝트 이름: UP & Fight
- 프로젝트 지속기간: 2023.10.11-2023.10.12
- 개발 엔진 및 언어: Unity & C#
- 멤버 : 김진규
  
## 설명
|![image](https://github.com/kjg5370/PersonalAssignment/assets/105926662/54ccc821-de6f-46eb-9abb-f7c10ce340bb)
|:---:|
|시작 화면|

게임의 인트로 화면입니다.<br>
- Play 버튼 🦉<br>
MainScene으로 씬을 전환합니다.
- Rule 버튼 ⚔️<br>
게임의 조작 버튼을 알려줍니다.

### 게임 화면

|시작|움직이는 블록|적 조우|승리 시|패배 시|
|---|---|---|---|---|
|![image](https://github.com/kjg5370/PersonalAssignment/assets/105926662/6ffcee50-3edc-4aa6-83aa-6b3418ea5fda)|![image](https://github.com/kjg5370/PersonalAssignment/assets/105926662/f83cdb34-168b-4d02-86ed-114ce7093043)|![image](https://github.com/kjg5370/PersonalAssignment/assets/105926662/b0c5d959-6745-4cb7-90c8-516946a333c1)|![image](https://github.com/kjg5370/PersonalAssignment/assets/105926662/aab688c4-fc2f-473d-b30c-e3da1333b2ac)|![image](https://github.com/kjg5370/PersonalAssignment/assets/105926662/f5cb4e73-77c3-4f05-b532-e30b5c95d3c5)
|게임 시작 스폰 위치|블록이 위 아래로 움직임|적에게 가까이 가면 적이 공격|승리 시 Victory 글자와 함께 UI가 나타남|패배 시 GameOver 글자와 함께 UI가 나타남

게임의 플레이 화면입니다.<br>
- 스폰 위치 🦉<br>
플레이어는 맵의 정 가운데 스폰 되며 앞에 위치한 블록들을 잘 올라가서 적을 만나 쓰러트려야 됩니다.
- 움직이는 블록 🔎<br>
맵의 중간 부분에 위 아래로 움직이는 블록들이 존재합니다. 그것들을 잘 이용해서 더 높은 곳으로 올라갈 수 있습니다.
- 적 조우 ⚔️<br>
맵의 가장 위로 가면 적을 만날 수 있습니다. 적은 피가 많지 않지만 방심하면 질 수 있습니다.
- 승리 시 🥇<br>
승리 하면 Victory 라는 글자와 함께 UI가 출력됩니다. 가운데 Retry버튼을 누르면 StartScene으로 넘어갑니다.
- 패배 시 💀<br>
패배 하면 GameOver 라는 글자와 함께 UI가 출력됩니다. 가운데 Retry버튼을 누르면 StartScene으로 넘어갑니다.

## 게임 요소
- InputAction
  게임의 키보드 마우스의 값을 받아와 캐릭터를 움직입니다.

- Cinemachine
  메인 카메라 대신 Virtual Camera를 이용해 Game화면을 표시합니다.

- ScriptableObject
  Player와 Enemy 스크립터블 오브젝트와 플레이어의 바닥, 궁중, 공격 데이터등을 관리합니다.

- StateMachine
  Player와 Enemy의 상태를 정의하고 특정 조건이 만족하면 상태를 전환시킵니다.

- Characters
  - CharacterHealth
    캐릭터의 체력을 관리하고 체력감소, Die이벤트 등을 실행합니다.
  - CharacterUI
    캐릭터의 이름, 체력UI를 그리며, 메인 카메라 방향으로 UI를 회전시킵니다.
  - ForceReceiver
    주로 캐릭터의 움직임과 힘을 관리하기 위한 것으로, 특히 점프 및 외부 힘 적용에 사용될 수 있습니다.
  - Weapon
    무기의 충돌 감지와 데미지 및 넉백 설정 함수가 있습니다.
    
- Entities
  - ElevatorController
    블록을 Bottom 과 Top을 기준으로 움직입니다.
  - SetUI
    게임의 화면을 채우는 UI들을 관리합니다.
