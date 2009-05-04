#!/bin/bash

GRGENDIR=GrGenNET-V$1-`date +"%F"`
GRGENDIRSRC=$GRGENDIR-src

# export all
svn export https://pp.info.uni-karlsruhe.de/svn/firm/trunk/grgen $GRGENDIRSRC

# delete doc-sources
mv $GRGENDIRSRC/doc/grgen.pdf $GRGENDIRSRC/
mv $GRGENDIRSRC/doc/VeryShortIntroductionToVersion2.txt $GRGENDIRSRC/
rm -rf $GRGENDIRSRC/doc
mkdir $GRGENDIRSRC/doc
mv $GRGENDIRSRC/grgen.pdf $GRGENDIRSRC/doc/grgen.pdf
mv $GRGENDIRSRC/VeryShortIntroductionToVersion2.txt $GRGENDIRSRC/doc/VeryShortIntroductionToVersion2.txt

rm $GRGENDIRSRC/make_release.sh
rm $GRGENDIRSRC/make_betabins.sh
rm -rf $GRGENDIRSRC/todo

rm -rf $GRGENDIRSRC/engine-net-2/ChangeFileHeaders
rm -rf $GRGENDIRSRC/engine-net-2/test
rm -rf $GRGENDIRSRC/engine-net-2/out/examples/UML
rm -rf $GRGENDIRSRC/engine-net-2/out/examples/Firm-IFConv

# make tar
tar cjf $GRGENDIRSRC.tar.bz2 $GRGENDIRSRC
zip -r $GRGENDIRSRC.zip $GRGENDIRSRC


# export binaries and examples
svn export https://pp.info.uni-karlsruhe.de/svn/firm/trunk/grgen/engine-net-2/out/ $GRGENDIR

cp $GRGENDIRSRC/LICENSE.txt $GRGENDIR/

rm -rf $GRGENDIR/examples/UML
rm -rf $GRGENDIR/examples/Firm-IFConv

# make tar
tar cjf $GRGENDIR.tar.bz2 $GRGENDIR
zip -r $GRGENDIR.zip $GRGENDIR
