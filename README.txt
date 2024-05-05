[ Issue ]

1	총기 변경해도 장전 계속됨
	- 장전하는동안 다른 총기를 쓰게금 유도되는게 좋아서 냅둘생각
2	몬스터 공격 시, 일정 각도만 데미지 입게끔 설정
3	SG 추가
4	Mob 추가
5	인게임 무기창 스크롤링

[ AudioSource 위치 ]

1	Mob 프리팹들
2	Gun 오브젝트

ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

# 기능 추가 프로세스

[ 총 추가 ]

1	게임 매니저 스크립트에서 총기 설정값을 추가합니다.
2	Scripts/Guns/AR 을 복사하여 새 스크립트를 만든 후
	게임 매니저의 총기 설정값을 참조하여 각 필드에 할당합니다.
3	스크립트의 사격 감지 파트에서, 해당 무기의 개성을 추가합니다.
	예를 들면, SR은 BulletEffect 를 추가로 Instantiate 합니다.
4	Hierarchy/Soldier_demo/Gun 에 스크립트를 추가합니다.
5	추가한 스크립트에 사용할 프리팹을 연결합니다.
6	총 격발 사운드를 추가합니다.
	예를 들면, 총기 SG의 사운드명 형식은 Resources/Sounds/SG 입니다.
7	Scripts/Gun/Gun 스크립트에서 Switch 메서드의 else if 문을 추가합니다.
	다른 총기의 if 문을 복사한 후, 총기 이름만 변경하면 편리합니다.
8	총기 On / Off 두가지의 스프라이트를 Resources/Images 에 추가합니다.
9	Hierarchy/UI 에 총기 이미지를 추가합니다.
10	Scripts/UI/UI 스크립트에서 이미지와 스프라이트를 public 으로 선언합니다.
	ActiveGunImage 메서드에서 새 총기가 On 일 때 나머지 총기는 Off 되도록 코딩합니다.
11	Hierarchy/UI.UI(Script) 에 총기 이미지 / On & Off 스프라이트를 연결합니다.



키코드 & 총 이름을 딕셔너리로 따서
foreach 문으로 하나씩 다