[ AudioSource 위치 ]

1	Mob 프리팹들
2	Gun 오브젝트

ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

# 기능 추가 프로세스

[ 총 추가 ]

1	게임 매니저 스크립트에서 총기 설정값을 추가합니다.
2	Scripts/Guns/AR 을 복사하여 새 스크립트를 만든 후
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

[ 몬스터 추가 ]

1	GameManager 스크립트에 몬스터 속성을 추가합니다.
2	Scripts/Spider 를 복사하여 새 몬스터 스크립트를 생성한 후, 각 속성을 연결합니다.
3	Resources/Prefabs/Mobs 에 몬스터 프리팹을 추가합니다.
4	Animations/Spider 의 컨트롤러를 복사하여 같은 형식으로 애니메이션을 연결합니다.
5	프리팹에 Spider 와 같은 형식으로 컴포넌트를 부착합니다.
6	Hierarchy/Spawner 에 프리팹을 연결합니다.

[ 업그레이드 추가 ]

1	Resources/Images/Upgrade 폴더에 스프라이트를 추가합니다.
2	Scripts/UI/SelectPanel 스크립트에 스프라이트 이름과 같은 함수를 추가합니다.
3	함수에 업그레이드 할 내용을 추가하되, 수치는 GameManager 에서 조절하게 합니다.
4	GameManager 스크립트에 설명을 추가합니다.
	"스프라이트 이름_text_head" 과 "스프라이트 이름_text_body" 로 추가합니다.